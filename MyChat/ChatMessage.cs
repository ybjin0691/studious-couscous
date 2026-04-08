using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MyClub.MyChat;

public class ChatMessage : UserControl
{
    public ChatMessage(string userName, string message, DateTime timestamp, bool isMine, int maxWidth, byte[] image = null)
    {
        Console.WriteLine($"{userName} : {message} - {isMine}");

        if (isMine)
        {
            RightChatMessage(userName, message, timestamp, maxWidth);
        }
        else
        {
            LeftChatMessage(userName, message, timestamp, maxWidth, image);
        }
    }

    private void LeftChatMessage(string userName, string message, DateTime timestamp, int maxWidth, byte[] image = null)
    {
        PictureBox avatar = new RoundPictureBox
        {
            Size = new Size(45, 45),
            MinimumSize = new Size(45, 45),
            Location = new Point(0, 0),
            SizeMode = PictureBoxSizeMode.Zoom,
            Margin = new Padding(0, 5, 5, 5),
            BackColor = Color.LightGray,
        };

        if (image != null && image.Length > 0)
        {
            using (MemoryStream ms = new MemoryStream(image))
            {
                avatar.Image = Image.FromStream(ms);
                avatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        Label lblUserName = new Label
        {
            Text = userName,
            AutoSize = true,
            Font = new Font("맑은 고딕", 9),
            ForeColor = Color.Black,
            TextAlign = ContentAlignment.MiddleLeft,
            Location = new Point(50, 0)
        };

        LeftBalloonLabel leftBalloonLabel = new LeftBalloonLabel(maxWidth)
        {
            Text = message,
            BalloonColor = Color.White,
            BorderColor = Color.LightGray,
            ForeColor = Color.Black,
            AutoSize = true,
            Location = new Point(50, lblUserName.Bottom + 2)
        };

        Label lblTimestamp = new Label
        {
            Text = timestamp.ToString("HH:mm"),
            AutoSize = true,
            Font = new Font("맑은 고딕", 9),
            ForeColor = Color.Black,
            TextAlign = ContentAlignment.MiddleLeft,
            Location = new Point(leftBalloonLabel.Right + 5, leftBalloonLabel.Bottom - 25)
        };

       
        this.Controls.Add(avatar);
        this.Controls.Add(lblUserName);
        this.Controls.Add(leftBalloonLabel);
        this.Controls.Add(lblTimestamp);
    }

    private void RightChatMessage(string userName, string message, DateTime timestamp, int maxWidth)
    {
        Label lblTimestamp = new Label
        {
            Text = timestamp.ToString("HH:mm"),
            AutoSize = true,
            Font = new Font("맑은 고딕", 9),
            ForeColor = Color.Black,
            TextAlign = ContentAlignment.MiddleRight,
        };

        RightBalloonLabel rightBalloonLebel = new RightBalloonLabel(maxWidth)
        {
            Text = message,
            BalloonColor = Color.FromArgb(255, 235, 59),
            BorderColor = Color.LightGray,
            ForeColor = Color.Black,
            AutoSize = true,
        };

        this.Controls.Add(rightBalloonLebel);
        this.Controls.Add(lblTimestamp);

        rightBalloonLebel.Location = new Point((maxWidth - rightBalloonLebel.Width) - 20, 0);
        lblTimestamp.Location = new Point(rightBalloonLebel.Location.X - lblTimestamp.Width , rightBalloonLebel.Bottom - 25);
    }
}
