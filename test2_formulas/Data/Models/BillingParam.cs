using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test2_formulas.Data.Models
{
    public class BillingParam
    {
        public int BillingParamID { get; set; }

        [Display(Name = "Стоимость одной минуты процессорного времени")]
        [Required(ErrorMessage = "Значение параметра не задано")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MinuteCost { get; set; }

        [Display(Name = "Бесплатное процессорное время")]
        [Required(ErrorMessage = "Значение параметра не задано")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:T}", ApplyFormatInEditMode = true)]
        public DateTime FreeTime { get; set; }

        [Display(Name = "Коэфициент по времени")]
        [Required(ErrorMessage = "Значение параметра не задано")]
        public double TimeCoef { get; set; }

        [Display(Name = "Начало временного интервала UTC коэффициента")]
        [Required(ErrorMessage = "Значение параметра не задано")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:T}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        
        [Display(Name = "Конец временного интервала UTC коэффициента")]
        [Required(ErrorMessage = "Значение параметра не задано")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:T}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }



    }
}
