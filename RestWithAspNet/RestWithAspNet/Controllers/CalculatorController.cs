using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
       
        // GET api/values/5
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = double.Parse(firstNumber) + double.Parse(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("Sub/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = double.Parse(firstNumber) - double.Parse(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Mult/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = double.Parse(firstNumber) * double.Parse(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Div/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (decimal.Parse(secondNumber) == 0)
                {
                    return BadRequest("You can't divide by zero!");
                }
                var result = double.Parse(firstNumber) - double.Parse(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Mean/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = (double.Parse(firstNumber) + double.Parse(secondNumber))/2;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Sqrt/{firstNumber}")]
        public ActionResult<string> Sqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber) )
            {
                var result = Math.Sqrt(double.Parse(firstNumber));
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string numberString)
        {
            double number;
            bool isNumber = double.TryParse(numberString, System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo,
                                            out number);
            return isNumber;

        }


    }
}
