using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Enums
{
    public enum EnumPaymentMethod
    {
        PagSeguro = 1, // Assinatura mensal com recorrência (cartão de crédito)
        MercadoPago = 2 // Pacote avulso (pix, cartão, boleto)
    }
}
