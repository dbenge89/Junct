using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junct.WASM.Hosted.Shared.Models
{
    public class CalendarDay
    {
        [Key]
        public int UniqueNumber { get; set; }
        public int DayNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsEmpty { get; set; }
        public List<Meet> Meets { get; set; }
    }
}
