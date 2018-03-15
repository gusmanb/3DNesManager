using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Filters
{
    public class FileOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            //filter the methods that in the parameters contain IFormFile
            if (context.ApiDescription.ParameterDescriptions.Any(x => x.ModelMetadata?.UnderlyingOrModelType == typeof(IFormFile)))
            {
                //get the methods that in the parameters contain IFormFile in a list
                var fileParams = context.ApiDescription.ParameterDescriptions.Where(x => x.ModelMetadata?.UnderlyingOrModelType == typeof(IFormFile)).ToList();

                //not needed, since we know there should be at least one base on previous checks
                if (fileParams.Any())
                {

                    if (operation.Parameters == null)
                        operation.Parameters = new List<IParameter>();

                    //Get the names of the file parameters. We can have more in a single request (ex. File.Front and File.Back)
                    //Since swagger "digs down" to most basics parameters it disassembles the IFormFile (ex. for a parameter File.Front we would have: File.Front.ContentType, File.Front.ContentDisposition, File.Front.Headers....)
                    //We get just the base name (ex. File.Front)
                    var fileUploadParameterNames = fileParams.Select(fp => fp.Name).Distinct().ToList();
                    foreach (var param in fileUploadParameterNames)
                    {
                        //To know if the parameter is required (not sure if it works)
                        bool required = false;

                        //Find all the ids of the operators that we need to remove in DESCENDING order!
                        //Little trick when modifying  the list, to remove first the element with highest id, since if we do it the other way around the removing of a lower index first will move (shift) the higher indexes
                        var opIds = operation.Parameters.Where(p => p.Name.StartsWith(param)).Select(p => operation.Parameters.IndexOf(p)).OrderByDescending(p => (int)p).ToList();
                        foreach (var id in opIds)
                        {
                            //since we have the parameter check if it is required, but because of the swagger parameter disassembling  I don't think this works properly
                            required = operation.Parameters[id].Required;
                            //remove all the parameter that belong to a file
                            operation.Parameters.RemoveAt(id);
                        }

                        //operation.Consumes.Add("multipart/form-data");
                        //operation.Consumes.Add("application/form-data");

                        //Add a single parameter that represents a file (IFormFile)
                        operation.Parameters.Add(new NonBodyParameter()
                        {
                            Name = param,
                            Required = required,
                            Description = "upload a file",
                            In = "formData",
                            Type = "file"
                        });
                    }
                }

            }
        }
    }
}
