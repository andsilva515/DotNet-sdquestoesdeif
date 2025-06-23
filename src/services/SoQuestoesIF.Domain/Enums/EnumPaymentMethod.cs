using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Enums
{
    public enum EnumPaymentMethod
    {
        PagSeguro, // Assinatura mensal com recorrência (cartão de crédito)
        MercadoPago // Pacote avulso (pix, cartão, boleto)
    }
}
