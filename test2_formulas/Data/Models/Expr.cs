using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2_formulas.Data.Models
{
    public class Expr
    {

        public int ExprID { get; set; }

        [Required(ErrorMessage = "Не введено выражение")]
        [RegularExpression(@"[-+*/().\d]*", ErrorMessage = "Выражение содержит недопустимые символы")]

        [StringLength(50)]
        [Display(Name = "Выражение")]
        public string Expression { get; set; }

        //Stopwatch stopWatch = new Stopwatch();

        [Display(Name = "Результат")]
        public string Result { get; set; }

        [Display(Name = "Затраченное время мс.")]
        public string TimeSpan { get; set; }

        [Display(Name = "Стоимость вычисления")]
        [DisplayFormat(DataFormatString = "{0:F10}")]
        public double Cost { get; set; }

        [Display(Name = "Пользователь")]
        public User User { get; set; }
    }
}
