
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class UnreadedMessagesWidget
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.EventBox eventboxLabel;
		
		private global::Gtk.Label labelUnreadedMessages;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.UnreadedMessagesWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Vodovoz.UnreadedMessagesWidget";
			// Container child Vodovoz.UnreadedMessagesWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.eventboxLabel = new global::Gtk.EventBox ();
			this.eventboxLabel.Name = "eventboxLabel";
			// Container child eventboxLabel.Gtk.Container+ContainerChild
			this.labelUnreadedMessages = new global::Gtk.Label ();
			this.labelUnreadedMessages.Name = "labelUnreadedMessages";
			this.labelUnreadedMessages.Xalign = 0F;
			this.labelUnreadedMessages.UseMarkup = true;
			this.eventboxLabel.Add (this.labelUnreadedMessages);
			this.vbox1.Add (this.eventboxLabel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.eventboxLabel]));
			w2.Position = 0;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.eventboxLabel.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnEventboxLabelButtonPressEvent);
		}
	}
}
