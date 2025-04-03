using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Services
{
   public interface IImagemanagementService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection files, string src);
        Task DeleteImageAsync(string src);
    }
}
