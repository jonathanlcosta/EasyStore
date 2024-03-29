﻿using System.Runtime.Serialization;

namespace EasyStore.Shared.Dominio.Utils.Excecoes;

[Serializable]
public class AtributoObrigatorioExcecao : RegraDeNegocioExcecao
{
    public AtributoObrigatorioExcecao()
    {
    }
    public AtributoObrigatorioExcecao(string atributo) : base(atributo + " é obrigatório")
    {

    }

    protected AtributoObrigatorioExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}

