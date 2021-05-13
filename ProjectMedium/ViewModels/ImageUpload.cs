using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.ViewModels
{
    public class ImageUpload
    {

        public IFormFile File { get; set; }

        public string myObject { get; set; }
    }
}
