import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiLogIn } from 'react-icons/fi';

import api from '../../services/api';

import heroesImg from "../../assests/heroes.png";
import logoImg from "../../assests/logo.svg";
import './style.css'

export default function Logon(){

    const [Id, setId] = useState('');
    const history = useHistory();
    async function handleLogon(e){
      e.preventDefault();
      try {
        let res = await api.post('session', {Id});
        localStorage.setItem("id", res.data.id);
        localStorage.setItem("name", res.data.name);
        history.push('/profile');
      }catch {
        alert('Deu ruim');
      }
    }

    return (
      <div className="logon-container">
        <section className="form">
          <img src={logoImg} alt="Be The Hero" />

          <form onSubmit={handleLogon}>
            <h1> Faça seu logon </h1>
            <input
              placeholder="Sua ID"
              value={Id}
              onChange={e => setId(e.target.value)}
              />
            <button className="button" type="submit">
              Entrar
            </button>
            <Link to='/register' className="back-link">
              <FiLogIn size={16} color="#E02041" />
                Registrar
            </Link>
          </form>
        </section>
        <img src={heroesImg} alt="Heroes" />
      </div>
    );
}