using Microsoft.AspNetCore.Mvc;

namespace avaliacaoGuilhermeBaptista.Controllers
{
    public class CalculadoraController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
public ActionResult Calcular(int numero1, int numero2, string operacao)
{
    int resultado = 0;

    switch (operacao)
            {
                case "soma":
                    resultado = numero1 + numero2;
                    break;
                case "subtracao":
                    resultado = numero1 - numero2;
                    break;
                case "multiplicacao":
                    resultado = numero1 * numero2;
                    break;
                case "divisao":
                    // Verificar se o divisor não é zero antes de realizar a divisão
                    if (numero2 != 0)
                    {
                        resultado = numero1 / numero2;
                    }
                    else
                    {
                        ViewBag.ErroDivisaoPorZero = "Não é possível dividir por zero.";
                        return View("Index");
                    }
                    break;
                default:
                    ViewBag.ErroOperacaoInvalida = "Operação inválida.";
                    return View("Index");
            }

            ViewBag.Resultado = resultado;
            ViewBag.Operacao = operacao;

            return View("Resultado"); ;
        }
    }
}
