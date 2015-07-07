using System.Drawing;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Basepage
/// </summary>
public class Basepage:System.Web.UI.Page
{

    /// <summary>
    /// Converts the color of the resultant text
    /// </summary>
    /// <param name="message"></param>
    /// <param name="type"></param>
    public void ShowMessage(string message, MessageInfo type)
    {
        Label commonLabel = this.Page.Master.FindControl("CommonLabel") as Label;
        if (commonLabel != null)
        {
            switch (type)
            {
                case MessageInfo.Error:
                    commonLabel.ForeColor = Color.Red;
                    break;
                case MessageInfo.Information:
                    commonLabel.ForeColor = Color.Green;
                    commonLabel.Font.Bold = true;
                    break;
            }
            commonLabel.Text = message;
        }
    }
}
