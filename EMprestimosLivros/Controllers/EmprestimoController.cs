using EMprestimosLivros.Data;
using EMprestimosLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMprestimosLivros.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _db;
        
        
        
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }
        public IActionResult Cadastrar() 
        { 
         return View();
        }
        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if(Id == null || Id==0 ) 
            
            {
            return NotFound();
            
            }
        
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == Id);
            
            if(emprestimo == null) 
            
            {
                return NotFound();            
            }


            return View();
        }
        [HttpGet]
        public IActionResult Excluir(int? Id) 
        {  
            if (Id == null || Id==0 )
            {
                return NotFound();
            }
           EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == Id);

            if(emprestimo == null)
            {  return NotFound();}

            return View(emprestimo);
        }
        
        [HttpPost]
    
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();        
        }
        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid) 
            { _db.Emprestimos.Update(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            }
        return View(emprestimos);
        }
        [HttpPost]
        public IActionResult Excluir (EmprestimosModel emprestimo)
        {
            if(emprestimo==null)
            { 
                return NotFound();
            }
        _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
     
            return RedirectToAction("Index");
        }
    }

}
