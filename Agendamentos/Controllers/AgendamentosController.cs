using Agendamentos.Global;
using Agendamentos.Models;
using Agendamentos.Database;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
    [ApiController]
    [Route("api/agendamentos")]
    public class AgendamentosController : Controller
    {
        [HttpGet]
        [Route("GetAll")]

  
        public JsonResult GetAll()
        {

            try
            {
                List<Agendamento> ag = new List<Agendamento>();
                DbConsulta consulta = new DbConsulta();
                    ag = consulta.GetAll();

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
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("Get")]
        
        public JsonResult Get(string cod)
        {

            try
            {
                Agendamento ag = new Agendamento();
                DbConsulta consulta = new DbConsulta();
                 ag = consulta.Get(cod);
                Log.Save("Dados pegos com sucesso com o codigo");
                    return new JsonResult(new { success = true, data = ag });
                
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("Add")]
        
        public JsonResult Add(Agendamento ag)
        {
            try
            {
                DbConsulta consulta = new DbConsulta();
                bool a = consulta.Add(ag);
                Log.Save("Dados adicionados com sucesso");
                    return new JsonResult(new { success = true, msg = "Agendamento com " + ag.profissional + " adicionado com sucesso" });
                

            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }


        [HttpPut]
        [Route("Update")]

      
        public JsonResult Update(Agendamento ag)
        {
         

            try
            {
                DbConsulta consulta = new DbConsulta();
                bool result = consulta.Update(ag);
                if (result)
                {
                    Log.Save("Dados alterados com sucesso");
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

      
        public JsonResult Delete(string id)
        {
           

            try
            {
                DbConsulta consulta = new DbConsulta();
                bool result = consulta.Delete(id);
                if (result)
                {
                    Log.Save("Dados deletados com sucesso");
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
