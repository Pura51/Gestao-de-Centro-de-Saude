using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class Enfermeiro : Pessoa
    {
        #region Atributos
        
        private static int _proximoId = 1; //Gera Id automaticamente
        private int _idEnfermeiro;
        private List<Quarto> _quartos; 

        #endregion
    }
        
}
