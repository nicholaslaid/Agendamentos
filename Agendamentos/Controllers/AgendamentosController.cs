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

  
        public JsonResult GetAll(string token)
        {
            List<Agendamento> ag = new List<Agendamento>();

            try
            {
                Security security = new Security();
                if (security.ValidateToken(token))
                {
                    ag = Config.Agen;

                    if (ag.Count > 0)
                    {
                        Log.Save("Dados pegos com sucesso");
                        return new JsonResult(new { success = true, agendamento = ag });
                      
                    }
                    else
                    {
                        return new JsonResult(new { success = true, agendamento = "0 agendamentos na lista" });
                    }
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "Token invalido" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("Get")]
        
        public JsonResult Get(Guid id, string token)
        {
            Agendamento ag = new Agendamento();

            try
            {
                Security security = new Security();
                if (security.ValidateToken(token))
                {
                    ag = Config.Agen.Find(x => x.cod == id);
                    Log.Save("Dados pegos com sucesso com o codigo");
                    return new JsonResult(new { success = true, data = ag });
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "Token invalido" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("Add")]
        
        public JsonResult Add(Agendamento ag, string token)
        {
            try
            {
                Security security = new Security();
                if (security.ValidateToken(token))
                {
                    Config.Agen.Add(ag);
                    Log.Save("Dados adicionados com sucesso");
                    return new JsonResult(new { success = true, msg = "Agendamento com " + ag.profissional + " adicionado com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "Token invalido" });
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }


        [HttpPut]
        [Route("Update")]

      
        public JsonResult Update(Agendamento ag, string token)
        {
            int idx = -1;

            try
            {
                Security security = new Security();
                if (security.ValidateToken(token))
                {
                    idx = Config.Agen.FindIndex(x => x.cod == ag.cod);

                    if (idx >= 0)
                    {
                        Config.Agen[idx] = ag;
                        Log.Save("Dados alterados com sucesso");
                        return new JsonResult(new { success = true, msg = "Consulta " + ag.cod + " alterada com sucesso" });
                    }
                    else
                    {
                        return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                    }
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "Token invalido" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]

      
        public JsonResult Delete(Guid id, string token)
        {
            int idx = -1;

            try
            {
                Security security = new Security();
                if (security.ValidateToken(token))
                {
                    idx = Config.Agen.FindIndex(x => x.cod == id);

                    if (idx >= 0)
                    {
                        Config.Agen.RemoveAt(idx);
                        Log.Save("Dados deletados com sucesso");
                        return new JsonResult(new { success = true, msg = "Consulta " + id + " excluida com sucesso" });
                    }
                    else
                    {
                        return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                    }
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "Token invalido" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}
