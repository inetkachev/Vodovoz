using System;
using System.Linq;
using QS.DomainModel.UoW;
using Vodovoz.Domain;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Organizations;
using Vodovoz.Parameters;
using Vodovoz.Services;

namespace Vodovoz.Models
{
    public class Stage1OrganizationProvider : IOrganizationProvider
    {
        private readonly IOrganizationParametersProvider organizationParametersProvider;
        private readonly IOrderPrametersProvider orderPrametersProvider;

        public Stage1OrganizationProvider(IOrganizationParametersProvider organizationParametersProvider, IOrderPrametersProvider orderPrametersProvider)
        {
            this.organizationParametersProvider = organizationParametersProvider ?? throw new ArgumentNullException(nameof(organizationParametersProvider));
            this.orderPrametersProvider = orderPrametersProvider ?? throw new ArgumentNullException(nameof(orderPrametersProvider));
        }
        
        public Organization GetOrganization(IUnitOfWork uow, Order order)
        {
            if (uow == null) throw new ArgumentNullException(nameof(uow));
            if (order == null) throw new ArgumentNullException(nameof(order));
            
            if(IsOnlineStoreOrder(order)) {
                return GetOrganizationForOnlineStore(uow);
            }
            
            if (order.SelfDelivery) {
                return GetOrganizationForSelfDelivery(uow, order.PaymentType);
            }
            
            return GetOrganizationForOtherOptions(uow, order);
        }

        private Organization GetOrganizationForSelfDelivery(IUnitOfWork uow, PaymentType paymentType)
        {
            int organizationId = 0;
            switch(paymentType) {
                case PaymentType.barter:
                case PaymentType.cashless:
                case PaymentType.ContractDoc:
                    organizationId = organizationParametersProvider.VodovozOrganizationId;
                    break;
                case PaymentType.cash:
                case PaymentType.Terminal:
                case PaymentType.ByCard:
                    organizationId = organizationParametersProvider.VodovozSouthOrganizationId;
                    break;
                case PaymentType.BeveragesWorld:
                    organizationId = organizationParametersProvider.BeveragesWorldOrganizationId;
                    break;
                default:
                    throw new NotSupportedException($"Невозможно подобрать организацию, так как тип оплаты {paymentType} не поддерживается.");
            }

            return uow.GetById<Organization>(organizationId);
        }

        private bool IsOnlineStoreOrder(Order order)
        {
            return order.OrderItems.Any(x => x.Nomenclature.OnlineStore != null);
        }
        
        private Organization GetOrganizationForOnlineStore(IUnitOfWork uow)
        {
            return uow.GetById<Organization>(organizationParametersProvider.VodovozSouthOrganizationId);
        }
        
        private Organization GetOrganizationForOtherOptions(IUnitOfWork uow, Order order)
        {
            int organizationId = 0;
            switch(order.PaymentType) {
                case PaymentType.barter:
                case PaymentType.cashless:
                case PaymentType.ContractDoc:
                    organizationId = organizationParametersProvider.VodovozOrganizationId;
                    break;
                case PaymentType.cash:
                    organizationId = organizationParametersProvider.SosnovcevOrganizationId;
                    break;
                case PaymentType.Terminal:
                    organizationId = organizationParametersProvider.VodovozSouthOrganizationId;
                    break;
                case PaymentType.BeveragesWorld:
                    organizationId = organizationParametersProvider.BeveragesWorldOrganizationId;
                    break;
                case PaymentType.ByCard:
                    if(order.PaymentByCardFrom != null && order.PaymentByCardFrom.Id == orderPrametersProvider.PaymentByCardFromMobileAppId) {
                        organizationId = organizationParametersProvider.SosnovcevOrganizationId;
                    }
                    else {
                        organizationId = organizationParametersProvider.VodovozSouthOrganizationId;
                    }
                    break;
                default:
                    throw new NotSupportedException($"Тип оплаты {order.PaymentType} не поддерживается, невозможно подобрать организацию.");
            }

            return uow.GetById<Organization>(organizationId);
        }
        
        public int GetMainOrganization()
        {
            return ParametersProvider.Instance.GetIntValue("main_organization_id");
        }
    }
}