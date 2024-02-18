﻿using System.Runtime.Serialization;

namespace EasyStore.Shared.Dominio.Utils.Excecoes;

public class AtributoInvalidoExcecao : RegraDeNegocioExcecao
{
    public AtributoInvalidoExcecao()
    {
    }
    public AtributoInvalidoExcecao(string atributo) : base(atributo + " inválido")
    {
    }

    protected AtributoInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}


