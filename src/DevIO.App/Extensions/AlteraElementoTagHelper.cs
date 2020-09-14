using DevIo.Business.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DevIO.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-capacity-div")]
    public class AlteraElementoDivIndexTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAvulsoService _avulsoService;

        public AlteraElementoDivIndexTagHelper(IHttpContextAccessor contextAccessor, IAvulsoService avulsoService)
        {
            _contextAccessor = contextAccessor;
            _avulsoService = avulsoService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            if (_avulsoService.HaVagaDisponivel().Result)
                return;

            output.AddClass("divDisabled", HtmlEncoder.Default);
            output.Attributes.Add(new TagHelperAttribute("data-toggle", "tooltip"));
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "Não há mais vagas disponíveis"));
        }
    }

    [HtmlTargetElement("*", Attributes = "supress-capacity-link")]
    public class AlteraElementoLinkIndexTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAvulsoService _avulsoService;

        public AlteraElementoLinkIndexTagHelper(IHttpContextAccessor contextAccessor, IAvulsoService avulsoService)
        {
            _contextAccessor = contextAccessor;
            _avulsoService = avulsoService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            if (_avulsoService.HaVagaDisponivel().Result)
                return;

            output.Attributes.RemoveAll("href");
            output.Attributes.RemoveAll("class");
        }
    }
}
