﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QSReport;
using Vodovoz.Domain.Service;

namespace Vodovoz.Domain.Orders.Documents
{
	public class EquipmentTransferDocument:OrderDocument
	{
		/// <summary>
		/// Тип документа используемый для маппинга для DiscriminatorValue
		/// а также для определния типа в нумераторе типов документов.
		/// Создано для определения этого значения только в одном месте.
		/// </summary>
		public static new string OrderDocumentTypeValue { get => "equipment_transfer"; }

		#region implemented abstract members of OrderDocument

		public override OrderDocumentType Type {
			get {
				return OrderDocumentTypeValues[OrderDocumentTypeValue];
			}
		}

		public override QSReport.ReportInfo GetReportInfo ()
		{
			return new QSReport.ReportInfo {
				Title = String.Format ("Акт приема-передачи оборудования №{0}", ServiceClaim.Id),
				Identifier = "Documents.EquipmentTransfer",
				Parameters = new Dictionary<string, object> {
					{ "order_id",  Order.Id },
					{ "service_claim_id",ServiceClaim.Id }
				}
			};
		}

		#endregion

		ServiceClaim serviceClaim;

		[Display (Name = "Заявка на сервис")]
		public virtual ServiceClaim ServiceClaim {
			get { return serviceClaim; }
			set { SetField (ref serviceClaim, value, () => ServiceClaim); }
		}

		public override string Name {
			get { return String.Format ("Акт приема-передачи оборудования №{0}", serviceClaim.Id); }
		}

		public override DateTime? DocumentDate {
			get { return serviceClaim?.ServiceStartDate; }
		}

		public override PrinterType PrintType {
			get {
				return PrinterType.RDL;
			}
		}
	}
}

