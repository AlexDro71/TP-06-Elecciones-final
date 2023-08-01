using Microsoft.AspNetCore.Mvc;

namespace TPBase.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        List<Partido> partidos = BD.listarPartidos();
        ViewBag.Partidos = partidos;

        return View();
    }

    public IActionResult VerDetallePartido(int idPartido)
    {
        Console.WriteLine(idPartido);
        Partido infoPartido = BD.verInfoPartido(idPartido);
        ViewBag.InfoPartido = infoPartido;
        List<Candidato> candidatosPartido = BD.listaCandidatos(idPartido);
        ViewBag.CandidatosLista = candidatosPartido;

        return View();
    }

    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        Candidato cand = BD.verInfoCandidato(idCandidato);
        ViewBag.InfoCandidato = cand;
        return View();
    }

    public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.idPartido = idPartido;
        return View();
    }

    [HttpPost]
    public IActionResult GuardarCandidato(Candidato candidato)
    {
        BD.AgregarCandidato(candidato);
        Partido infoPartido = BD.verInfoPartido(candidato.idPartido);
        ViewBag.InfoPartido = infoPartido;
        List<Candidato> candidatosPartido = BD.listaCandidatos(candidato.idPartido);
        ViewBag.CandidatosLista = candidatosPartido;


        return View("VerDetallePartido");
    }

    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        Partido infoPartido = BD.verInfoPartido(idPartido);
        ViewBag.InfoPartido = infoPartido;
        List<Candidato> candidatosPartido = BD.listaCandidatos(idPartido);
        ViewBag.CandidatosLista = candidatosPartido;

        return View("VerDetallePartido");
    }

    public IActionResult Elecciones()
    {
        return View("Elecciones");
    }

    public IActionResult Creditos()
    {
        return View("Creditos");
    }

}
