﻿using System.Runtime.Serialization;

namespace EasyStore.Shared.Dominio.Utils.Excecoes;

[Serializable]
public class RegraDeNegocioExcecao : Exception
{
    public RegraDeNegocioExcecao()
    {
    }

    public RegraDeNegocioExcecao(string mensagem) : base(mensagem)
    {

    }

    public RegraDeNegocioExcecao(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected RegraDeNegocioExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}


