using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class ImageFile
    {
        public int ImageId { get; set; }
        public string fileName { get; set; }
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string Size { get; set; }
    }
}
