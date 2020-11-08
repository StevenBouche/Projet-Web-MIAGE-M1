﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Forum.SignalR
{
    public interface IForumHub
    {
        Task SendMessage(string message);
        string GetIdUser();
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ForumHub : Hub, IForumHub
    {

        public ForumHub(IUserIdProvider userId)
        {

        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(this.GetIdUser(), "SignalR Users");

            await base.OnConnectedAsync();
            Console.WriteLine("Connected");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(this.GetIdUser(), "SignalR Users");
            await base.OnDisconnectedAsync(exception);
            Console.WriteLine("Disconnect");
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("newMessage", this.GetIdUser(), message);
        }

        public string GetIdUser()
        {
            return this.Context.UserIdentifier;
        }

    }
}
