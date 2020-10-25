using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Domain.Services
{
    public class SampleItemServiceBase : ServiceBase<SampleItem>
    {
        protected readonly ISampleItemRepository _rep;
        protected readonly IValidatorSpecification<SampleItem> _validation;
        protected readonly IWarningSpecification<SampleItem> _warning;


        public SampleItemServiceBase(ISampleItemRepository rep, IValidatorSpecification<SampleItem> validation, IWarningSpecification<SampleItem> warning, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
            this._user = user;
            this._validation = validation;
            this._warning = warning;
        }

        public virtual async Task<SampleItem> GetOne(SampleItemFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<SampleItem>> GetByFilters(SampleItemFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<SampleItem>> GetByFiltersPaging(SampleItemFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(SampleItem sampleitem)
        {
            this._rep.Remove(sampleitem);
        }

        public virtual Summary GetSummary(PaginateResult<SampleItem> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

        public override async Task<SampleItem> Save(SampleItem sampleitem, bool questionToContinue = false)
        {
			var sampleitemOld = await this.GetOne(new SampleItemFilter { SampleItemId = sampleitem.SampleItemId, QueryOptimizerBehavior = "OLD" });
			var sampleitemOrchestrated = await this.DomainOrchestration(sampleitem, sampleitemOld);

            if (questionToContinue)
            {
                if (this.Continue(sampleitemOrchestrated, sampleitemOld) == false)
                    return sampleitemOrchestrated;
            }

            return this.SaveWithValidation(sampleitemOrchestrated, sampleitemOld);
        }

        public override async Task<SampleItem> SavePartial(SampleItem sampleitem, bool questionToContinue = false)
        {
            var sampleitemOld = await this.GetOne(new SampleItemFilter { SampleItemId = sampleitem.SampleItemId, QueryOptimizerBehavior = "OLD" });
			var sampleitemOrchestrated = await this.DomainOrchestration(sampleitem, sampleitemOld);

            if (questionToContinue)
            {
                if (this.Continue(sampleitemOrchestrated, sampleitemOld) == false)
                    return sampleitemOrchestrated;
            }

            return SaveWithOutValidation(sampleitemOrchestrated, sampleitemOld);
        }

        protected override SampleItem SaveWithOutValidation(SampleItem sampleitem, SampleItem sampleitemOld)
        {
            sampleitem = this.SaveDefault(sampleitem, sampleitemOld);
			this._cacheHelper.ClearCache();

			if (!sampleitem.IsValid())
			{
				this._validationResult = sampleitem.GetDomainValidation();
				this._validationWarning = sampleitem.GetDomainWarning();
				return sampleitem;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return sampleitem;
        }

		protected override SampleItem SaveWithValidation(SampleItem sampleitem, SampleItem sampleitemOld)
        {
            if (!this.IsValid(sampleitem))
				return sampleitem;
            
            sampleitem = this.SaveDefault(sampleitem, sampleitemOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return sampleitem;
        }
		
		protected virtual bool IsValid(SampleItem entity)
        {
            var isValid = true;
            if (!this.DataAnnotationIsValid() || !entity.IsValid())
            {
                if (this._validationResult.IsNull())
                    this._validationResult = entity.GetDomainValidation();
                else
                    this._validationResult.Merge(entity.GetDomainValidation());

                if (this._validationWarning.IsNull())
                    this._validationWarning = entity.GetDomainWarning();
                else
                    this._validationWarning.Merge(entity.GetDomainWarning());

                isValid = false;
            }

            this.Specifications(entity);
            if (!this._validationResult.IsValid)
                isValid = false;

            return isValid;
        }

		protected virtual void Specifications(SampleItem sampleitem)
        {
            this._validationResult  = this._validationResult.Merge(this._validation.Validate(sampleitem));
			this._validationWarning  = this._validationWarning.Merge(this._warning.Validate(sampleitem));
        }

        protected virtual SampleItem SaveDefault(SampleItem sampleitem, SampleItem sampleitemOld)
        {
			

            var isNew = sampleitemOld.IsNull();			
            if (isNew)
                sampleitem = this.AddDefault(sampleitem);
            else
				sampleitem = this.UpdateDefault(sampleitem);

            return sampleitem;
        }
		
        protected virtual SampleItem AddDefault(SampleItem sampleitem)
        {
            sampleitem = this._rep.Add(sampleitem);
            return sampleitem;
        }

		protected virtual SampleItem UpdateDefault(SampleItem sampleitem)
        {
            sampleitem = this._rep.Update(sampleitem);
            return sampleitem;
        }
				
		public virtual async Task<SampleItem> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleItem.SampleItemFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<SampleItem> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleItem.SampleItemFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
