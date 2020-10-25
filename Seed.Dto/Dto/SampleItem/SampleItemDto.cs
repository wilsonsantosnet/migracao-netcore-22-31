using System.ComponentModel.DataAnnotations;
using Common.Domain.Base;
using System;

namespace Seed.Dto
{
	public class SampleItemDto  : DtoBase
	{
	
        

        public virtual int SampleItemId {get; set;}

        [Required(ErrorMessage="SampleItem - Campo Name é Obrigatório")]
        [MaxLength(150, ErrorMessage = "SampleItem - Quantidade de caracteres maior que o permitido para o campo Name")]
        public virtual string Name {get; set;}

        

        public virtual int SampleId {get; set;}


		
	}
}
