using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.Extensions
{
    public class JsonResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
    }
}
