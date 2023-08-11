using Agendamentos.Global;
using Agendamentos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class AgendamentosController : Controller
    {
        [HttpGet]
        [Route("GetAll")]

        //foi
        public JsonResult GetAll()
        {
            List<Agendamento> ag = new List<Agendamento>();

            try
            {
                ag = Config.Agen;

                if (ag.Count > 0)
                {
                    return new JsonResult(new { success = true, agendamento = ag });
                }
                else
                {
                    return new JsonResult(new { success = true, agendamento = "0 agendamentos na lista" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("Get")]
        //foi
        public JsonResult Get(Guid id)
        {
            Agendamento ag = new Agendamento();

            try
            {
                ag = Config.Agen.Find(x => x.cod == id);

                return new JsonResult(new { success = true, data = ag });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("Add")]
        //n foi
        public JsonResult Add(Agendamento ag)
        {
            try
            {
                Config.Agen.Add(ag);
                return new JsonResult(new { success = true, msg = "Agendamento com " + ag.profissional + " adicionado com sucesso" });


            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }


        [HttpPut]
        [Route("Update")]

        //foi
        public JsonResult Update(Agendamento ag)
        {
            int idx = -1;

            try
            {
                idx = Config.Agen.FindIndex(x => x.cod == ag.cod);

                if (idx >= 0)
                {
                    Config.Agen[idx] = ag;
                    return new JsonResult(new { success = true, msg = "Consulta " + ag.cod + " alterada com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]

        //foi
        public JsonResult Delete(Guid id)
        {
            int idx = -1;

            try
            {
                idx = Config.Agen.FindIndex(x => x.cod == id);

                if (idx >= 0)
                {
                    Config.Agen.RemoveAt(idx);
                    return new JsonResult(new { success = true, msg = "Consulta " + id + " excluida com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}
