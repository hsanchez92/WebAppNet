using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respuestas
{
    public class RespuestaDetalleDescripcion
    {
        public class Snapshot
        {
            [DefaultValue("")] public string  url { get; set; }
            [DefaultValue(0)]  public int width { get; set; }
            [DefaultValue(0)]  public int height { get; set; }
            [DefaultValue("")]  public string  status { get; set; }

        }
            [DefaultValue("")]public string  text { get; set; }
            [DefaultValue("")]public string  plain_text { get; set; }
            public DateTime last_updated { get; set; }
            public DateTime date_created { get; set; }
            public Snapshot snapshot { get; set; }
        
    }
}
