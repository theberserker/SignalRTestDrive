This is very basic example project for SignalR. The application is created on default ASP.NET MVC 5 Template with Authentication.

Project currently consists of two examples:
- Chat
- Connected users

**Chat** is trivial, mostly copy-paste example from the official SignalR tutorial. It only adds the name from a login, if there is one. It is a *Hub* implementation.

**Connected users** is also very simple implementation and is based on *PersistentConnection* implementation. It could be easily Hub as well.
It displays realtime when different users get connected.
When users connect or disconnect this is tracked by `ConnectedUsersManager` and manager is using a `ConnectedUsersRepository` to store information about connected users.
