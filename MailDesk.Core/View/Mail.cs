using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MailDesk.Core.View
{
    public class Mail : ListBoxItem
    {
        protected Label mailTitle;
        protected Label sender;

        protected ContentControl content;

        public Mail()
        {

            mailTitle = new Label();
            sender = new Label();
            mailTitle.Content = "Mail";
            sender.Content = "Me";

            StackPanel panel = new StackPanel();

            panel.Children.Add(mailTitle);
            panel.Children.Add(sender);
            this.Content = panel;
        }

        public void AddContent(object content)
        {
            //this.Content
        }
    }
}
