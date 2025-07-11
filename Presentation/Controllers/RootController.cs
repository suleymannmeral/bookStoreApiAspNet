﻿using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;


namespace Presentation.Controllers;

[ApiController]
[Route("api")]
public class RootController:ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public RootController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    [HttpGet(Name ="GetRoot")]
    public async Task<IActionResult> GetRoot([FromHeader(Name ="Accept")]string mediaType)
    {
        if (mediaType.Contains("application/vnd.btkakademi.apiroot"))
        {
            var list = new List<Link>()
            {
                new Link()
                {
                    Href=_linkGenerator.GetUriByName(HttpContext,nameof(GetRoot),new{}),
                    Rel="_self",
                    Method="GET",
                },
                new Link()
                {
                    Href=_linkGenerator.GetUriByName(HttpContext,nameof(BooksController.GetAllBooksAsync),new{}),
                    Rel="books",
                    Method="GET",
                },
                new Link()
                {
                    Href=_linkGenerator.GetUriByName(HttpContext,nameof(BooksController.CreateBookAsync),new{}),
                    Rel="_self",
                    Method="POST",
                }
            };
            return Ok(list);
        };
        return NoContent(); //204
    }

}
