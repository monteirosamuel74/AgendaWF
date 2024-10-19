using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWF
{
    public class Contato
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private String nome;

		public String Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		private String email;

		public String Email
		{
			get { return email; }
			set { email = value; }
		}

	}
}
