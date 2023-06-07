using RabbitMQ.Client;

namespace Jones.RabbitMQ;

public class RabbitMQClient
{
    private const string HostName = "hostname";
    private const string Port = "port";
    private const string UserName = "username";
    private const string Password = "password";

    public IModel Channel { get; }

    public RabbitMQClient(string connectionString)
    {
        var parameters = GetParameters(connectionString);
        var factory = new ConnectionFactory
        {
            HostName = parameters[HostName],
            UserName = parameters[UserName],
            Password = parameters[Password],
            Port = Convert.ToInt32(parameters[Port]),
        };
        var connection = factory.CreateConnection();
        Channel = connection.CreateModel();
    }

    private static Dictionary<string, string> GetParameters(string connectionString)
    {
        // 127.0.0.1:5672,username=root,password=bet123
        var parameterList = connectionString.Split(",");
        var parameters = new Dictionary<string, string>();
        foreach (var parameter in parameterList)
        {
            if (parameter.Contains(":"))
            {
                var hostNameAndPort = parameter.Split(":");
                parameters.Add(HostName, hostNameAndPort[0]);
                parameters.Add(Port, hostNameAndPort[1]);
            } 
            else if (parameter.Contains("="))
            {
                var parameterKeyValue = parameter.Split("=");
                parameters.Add(parameterKeyValue[0], parameterKeyValue[1]);
            }
            else
            {
                parameters.Add(HostName, parameter);
            }
        }

        return parameters;
    }
}