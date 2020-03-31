import React, { useState, useEffect } from 'react';
import { Link, useHistory } from "react-router-dom";
import { FiPower, FiTrash2 } from "react-icons/fi";

import api from '../../services/api';

import "./styles.css";
import logoImg from "../../assests/logo.svg";

export default function Profile(){
  const history = useHistory();
  const OngName = localStorage.getItem('name');
  const OngId = localStorage.getItem('id');
  const [incidents, setIncidents] = useState([]);
  useEffect(() => {
    api.get('profile', {
      headers : {
        ongsId: OngId,
      }
    }).then(res => {
      setIncidents(res.data);
    })
  }, [OngId]);

  async function handleDelete(id){
    try{
      await api.delete(`incidents/${id}`, {
        headers : {
          ongsId: OngId,
        }
      });
      setIncidents(incidents.filter(item => item.id !== id));
    } catch(e){
      alert('Deu Ruim.');
    }
  }

  function handleLogout(){
    localStorage.clear();
    history.push('/');
  }
    return (
        <div className="profile-container">
        <header>
          <img src={logoImg} alt="Be The Hero" />
         <span>Olá <b>{OngName}</b></span>
  
          <Link to="/incidents/new" className="button">
            Cadastrar novo caso
          </Link>
  
          <button type="button" onClick={handleLogout}>
            <FiPower size={18} color="#e02041" />
          </button>
        </header>
  
        <h1> Casos cadastrados</h1>
  
        <ul>
          {incidents.map(item => (
            <li key={item.id}>
              <strong>CASO:</strong>
              <p>{item.title}</p>
              <strong>DESCRIÇÃO:</strong>
              <p>{item.description}</p>
              <strong>VALOR:</strong>
              <p>{Intl.NumberFormat('pt-br', { style: 'currency', currency: 'BRL' }).format(item.value)}</p>
              <button type="button" onClick={() => handleDelete(item.id)}>
                <FiTrash2 size={23} color="#a8a8b3" />
              </button>
            </li>
          ))}
        </ul>
      </div>
    );
}