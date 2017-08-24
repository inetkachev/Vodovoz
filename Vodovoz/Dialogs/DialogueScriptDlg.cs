﻿using System;
using System.Collections.Generic;
using QSOrmProject;
using QSTDI;
using Vodovoz.Domain;
using Vodovoz.ViewWidgets.DialogueScriptWidgets;

namespace Vodovoz.Dialogs
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class DialogueScriptDlg : Gtk.Bin, ITdiTab, IOrmDialog
	{
		Dictionary<string, ScriptTreeElement> scriptTreeElements;
		Dictionary<string, ScriptTreeObject> scriptTreeObjects = new Dictionary<string, ScriptTreeObject>();
		Dictionary<ScriptTreeElement, DialogueBaseWidget> widgets = new Dictionary<ScriptTreeElement, DialogueBaseWidget>();
		IUnitOfWork UoW;

		public DialogueScriptDlg()
		{
			this.Build();
			UoW = UnitOfWorkFactory.CreateWithoutRoot();
			scriptTreeElements = GetAllScriptElements();
			Configure();
		}

		public void Configure()
		{
			if(scriptTreeElements.TryGetValue("START", out var element)) {
				NextElement(element);
			} else {
				return;
			}
		}

		#region ITdiTab_implementation

		public HandleSwitchIn HandleSwitchIn { get; private set; }

		public HandleSwitchOut HandleSwitchOut { get; private set; }

		public string TabName { get { return "NYI"; } private set {; } }

		public ITdiTabParent TabParent { get ; set ; }

		public bool FailInitialize { get { return false;  } }

		IUnitOfWork IOrmDialog.UoW { get { return this.UoW; } }

		public object EntityObject => throw new NotImplementedException();

		public event EventHandler<TdiTabNameChangedEventArgs> TabNameChanged;
		public event EventHandler<TdiTabCloseEventArgs> CloseTab;

		public bool CompareHashName(string hashName)
		{
			throw new NotImplementedException();
		}

		#endregion

		public Dictionary<string, ScriptTreeElement> GetAllScriptElements()
		{
			Dictionary<string, ScriptTreeElement> allScriptElements = new Dictionary<string, ScriptTreeElement>();

			var steQuery = UoW.Session.CreateCriteria<ScriptTreeElement>()
							  .List<ScriptTreeElement>();

			foreach(ScriptTreeElement ste in steQuery) {
				allScriptElements.Add(ste.Name, ste);
			}

			return allScriptElements;
		}

		void OnScriptElementDone(object sender, ScriptElementDoneEventArgs e)
		{
			if(e.Result != null)
			{
				scriptTreeObjects[e.CurrentElement] = e.Result;
			}

			if(e.NextElement == null)
			{
				return;
			}

			NextElement(e.NextElement);
		}

		void OnScriptElementChanged(object sender, ScriptElementDoneEventArgs e)
		{
			if(e.Result != null) 
			{
				scriptTreeObjects[e.CurrentElement] = e.Result;

				// Цикл проверяет, есть ли в зависимостях у уже созданных элементов обновлённый элемент, и рефрешит значение в них.
				foreach(KeyValuePair<ScriptTreeElement, DialogueBaseWidget> widget in widgets)
				{
					if(widget.Key.Dependency == e.CurrentElement)
					{
						widget.Value.RefreshDependency(e.Result);
					}
				}
			}
		}
	

		public void NextElement(ScriptTreeElement ste)
		{
			var element = new DialogueBaseWidget(UoW, ste, GetDependency(ste));
			element.ScriptElementDone += OnScriptElementDone;
			element.ScriptElementChanged += OnScriptElementChanged;
			element.Show();
			vbox2.PackStart(element, false, true, 0);
			widgets[ste] = element;
		}

		ScriptTreeObject GetDependency(ScriptTreeElement ste)
		{
			if(ste.Dependency != null && scriptTreeObjects.ContainsKey(ste.Dependency))
			{
				return scriptTreeObjects[ste.Dependency];
			}

			return null;
		}
	}
}
