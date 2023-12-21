// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const connection=new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

        

// receive the message
connection.on("ReceiveMessage",(user,message)=>{
    const rec_message=user +":"+message;
    const li=document.createElement("li");
    li.textContent=rec_message;
    document.getElementById("messagesList").appendChild(li);
});
connection.start().catch(err=>console.error(err.toString()));

//Send the Message
document.getElementById("sendMessage").addEventListener("click",event=>{
    const user=document.getElementById("userName").value;
    const message=document.getElementById("userMessage").value;
    connection.invoke("SendMessage",user,message).catch(err=>console.error(err.toString()));
    event.preventDefault();
});


// connection.start()
//     .then(() => {
//         // Send the Message
//         document.getElementById("sendMessage").addEventListener("click", event => {
//             const user = document.getElementById("userName").value;
//             const message = document.getElementById("userMessage").value;
//             connection.invoke("SendMessage", user, message)
//                 .catch(err => console.error(err.toString()));
//             event.preventDefault();
//         });
//     })
    // .catch(err => console.error(err.toString()));


