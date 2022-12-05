﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.services
{
    class JsonService
    {
        public JsonService()
        {
        }

        public void Save<T>(T ob, String path)
        {
            string personasJson = JsonConvert.SerializeObject(ob);
            File.WriteAllText(path, personasJson);
        }

        public object Open<T>(String path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText("personas.json"));

        }



    }
}