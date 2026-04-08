using Microsoft.AspNetCore.Mvc;
using Calc.Models;

namespace Calc.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            var model = new CalcModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            switch (model.Operation)
            {
                case "+":
                    model.Result = model.Operand1.Value + model.Operand2.Value;
                    break;

                case "-":
                    model.Result = model.Operand1.Value - model.Operand2.Value;
                    break;

                case "*":
                    model.Result = model.Operand1.Value * model.Operand2.Value;
                    break;

                case "/":
                    if (model.Operand2 != 0)
                        model.Result = (decimal)model.Operand1.Value / model.Operand2.Value;
                    break;
            }

            string expr = $"{model.Operand1} {model.Operation} {model.Operand2} = {model.Result}";
            Response.Cookies.Append("calc", expr);

            ViewBag.CheckValue = 10;

            return View(model);
        }

        public IActionResult Result()
        {
            string expression = Request.Cookies["calc"];

            if (expression == null)
                expression = "Нет данных";

            // ЗАМЕНА "=" на " равно "
            int index = expression.IndexOf("=");

            if (index != -1)
            {
                expression = expression.Remove(index, 1);
                expression = expression.Insert(index, " равно ");
            }

            ViewBag.Expression = expression;

            return View();
        }

    }
}
