//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FunerariaMuertoFeliz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class parque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public parque()
        {
            this.boleta = new HashSet<boleta>();
        }
    
        public int idparque { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string horario { get; set; }
        public string telefono { get; set; }
        public int region_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<boleta> boleta { get; set; }
        public virtual region region { get; set; }
    }
}
