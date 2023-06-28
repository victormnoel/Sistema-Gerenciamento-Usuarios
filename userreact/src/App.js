import './App.css';
import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

function App() {

  const baseUrl = "https://localhost:7197/api/User/GetAll";

  const [data, setData] = useState([]);
  const[modalIncluir, setModalIncluir]= useState(false);

  const [userSelecionado, setUserSelecionado]=useState(
  {
    id: '',
    name: '',
    email: '',
    age: ''
  })

  const abrirFecharModalIncluir= () =>{
    setModalIncluir(!modalIncluir);
  }

  const handleChange = e=>{
    const {name, value} = e.target;
    setUserSelecionado({
      ...userSelecionado,[name]: value
    });
    console.log(userSelecionado);
  }

  const pedidoGet= async() => {
    await axios.get(baseUrl).then(response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  const pedidoPost= async() =>{
    delete userSelecionado.id;
    userSelecionado.age=parseInt(userSelecionado.age);
    await axios.post(baseUrl, userSelecionado)
    .then(response=>{
      setData(data.concat(response.data));
      abrirFecharModalIncluir();
    }).catch(error=>{
      console.log(error);
    })
  }
  
  useEffect(()=> {
    pedidoGet();
  })

  return (
    <div className="App">
      <br/>
      <h3>Gerenciamento de Usuarios</h3>
      <header>
        <button className="btn btn-success" onClick={()=> abrirFecharModalIncluir()}>Incluir novo usuario</button>
      </header>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Ano</th>
            <th>Operação</th>
          </tr>
        </thead>
        <tbody>
          {data.map(user=> (
            <tr key={user.id}>
              <td>{user.id}</td>
              <td>{user.name}</td>
              <td>{user.email}</td>
              <td>{user.age}</td>
              <td>
                <button className="btn btn-primary">Editar</button> {"  "}
                <button className="btn btn-danger">Deletar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <Modal isOpen={modalIncluir}>
        <ModalHeader>Incluir usuarios</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Nome:</label>
            <br/>
            <input type="text" className="form-control" name="name" onChange={handleChange}/>
            <br/>
            <label>Email:</label>
            <br/>
            <input type="text" className="form-control" name="email" onChange={handleChange}/>
            <br/>
            <label>Idade:</label>
            <br/>
            <input type="text" className="form-control" name="age" onChange={handleChange}/>
            <br/>
          </div>
        </ModalBody>

        <ModalFooter>
          <button className="btn btn-primary" onClick={() => pedidoPost()}>Incluir</button> {"  "}
          <button className="btn btn-danger" onClick={() => abrirFecharModalIncluir()}>Cancelar</button>
        </ModalFooter>
      </Modal>
    </div>
  );
}

export default App;
