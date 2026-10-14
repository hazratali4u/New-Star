namespace SAMS.Common.Classes
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    public class WebMsgBox
    {
        protected static Hashtable handlerPages = new Hashtable();

        private WebMsgBox()
        {
        }

        private static void CurrentPageUnload(object sender, EventArgs e)
        {
            Queue queue = (Queue) handlerPages[HttpContext.Current.Handler];
            if (queue != null)
            {
                StringBuilder builder = new StringBuilder();
                int count = queue.Count;
                builder.Append("<script language='javascript'>");
                while (count > 0)
                {
                    count--;
                    builder.Append("alert( \"" + Convert.ToString(queue.Dequeue()).Replace("\"", "'") + "\" );");
                }
                builder.Append("</script>");
                handlerPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }
        }

        public static void Show(string Message)
        {
            if (!handlerPages.Contains(HttpContext.Current.Handler))
            {
                Page handler = (Page) HttpContext.Current.Handler;
                if (handler != null)
                {
                    Queue queue = new Queue();
                    queue.Enqueue(Message);
                    handlerPages.Add(HttpContext.Current.Handler, queue);
                    handler.Unload += new EventHandler(WebMsgBox.CurrentPageUnload);
                }
            }
            else
            {
                ((Queue) handlerPages[HttpContext.Current.Handler]).Enqueue(Message);
            }
        }
    }
}

