import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { FiArrowLeft } from "react-icons/fi";

import api from '../../services/api';

import './styles.css';
import logoImg from "../../assests/logo.svg";

export default function NewIncident(){
    const history = useHistory();
    const OngId = localStorage.getItem('id');
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [value, setValue] = useState(Number);

    //Fn para cadastarar
    async function handleCadastrar(e){
      e.preventDefault();
      const data = {
        title, description, value
      };

      try {
        let res = await api.post('incidents', data, {
          headers : {
            ongsId: OngId,
          }
        });
        
        history.push('/profile');
      }catch {
        alert('Deu ruim');
      }
    }
    return(
        <div className="new-incident-container">
          <div className="content">
            <section>
              <img src={logoImg} alt="Be The Hero" />
              <h1>Cadastrar novo caso</h1>
              <p>
                Descreva o caso detalhadamente para encontrar um herói para resolver
                isso.
              </p>

              <Link to="/profile" className="back-link">
                <FiArrowLeft size={16} color="#e02041" />
                Voltar para home
              </Link>
            </section>
            <form onSubmit={handleCadastrar}>
              <input
                placeholder="Título do caso"
                value={title}
                onChange={e => setTitle(e.target.value)}
              />
              <textarea
                placeholder="Descrição"
                value={description}
                onChange={e => setDescription(e.target.value)}
              />
              <input
                placeholder="Valor em reais"
                value={value}
                onChange={e => setValue(e.target.value)}
              />
              <button className="button" type="submit">
                Cadastrar
              </button>
            </form>
          </div>
        </div>
    );
}