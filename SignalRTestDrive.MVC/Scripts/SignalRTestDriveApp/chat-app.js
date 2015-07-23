//http://www.asp.net/signalr/overview/getting-started/tutorial-getting-started-with-signalr
$(function (isSignedIn) {
    // Declare a proxy to reference the hub. 
    var chat = $.connection.chatHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message. 
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page. 
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // If user is not logged in, get the user name and store it to prepend to messages.
    if (!isSignedIn) {
        var username = prompt('Enter your name:', '');
        $('#displayname').val(username);
    }
    // Set initial focus to message input box.  
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start()
        .done(function(conn) {
            console.log('Client connected to ChatHub. Connection ID=' + conn.id);

            $('#sendmessage').click(function() {
                submitChat();
            });

            $(document).keypress(function(e) {
                if (e.which == 13) {
                    submitChat();
                }
            });

            function submitChat() {
                // Call the Send method on the hub. 
                chat.server.send($('#displayname').val(), $('#message').val());
                // Clear text box and reset focus for next comment. 
                $('#message').val('').focus();
            }
        })
        .fail(function () { console.log('Could not connect to ChatHub'); });
}(window.isSignedIn));