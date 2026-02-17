using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Providers.JsonProviders
{
    public class JsonParticlesDataProvider : IParticleDataProvider
    {
        private readonly string _particlePath;
        private ParticlesData _data;

        public JsonParticlesDataProvider(string dataPath)
        {
            this._particlePath = Path.Combine(dataPath, "particles.json");
        }

        public ParticlesData GetParticles()
        {
            if (_data == null)
            {
                var json = File.ReadAllText(_particlePath);
                _data = JsonSerializer.Deserialize<ParticlesData>(json, Helpers.JsonHelpers.SerializerOptions)!;
            }

            return _data;
        }
    }
}
