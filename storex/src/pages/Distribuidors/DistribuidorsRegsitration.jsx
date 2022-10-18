import React from 'react'
import "./DistribuidorsRegistration.css"
import Sidebar from '../../components/Sidebar/Sidebar'
import axios from 'axios'

const DistribuidorsRegistration = () => {
  return (
    <div className='session_register'>
      <Sidebar />
      <div className='form_session'>
        <div id='title' className='text-center w-100 '>
          <h1>Distribuidors Registration</h1>
        </div>
        <form id='userForm' action="" className='container'>
          <div className='txt_field'>
            <input type="text" name="username" className='input_login' required />
            <span></span>
            <label className='w-100'>Name</label>
          </div>
          <div className='txt_field'>
            <input type="text" name="username" className='input_login' required />
            <span></span>
            <label className='w-100'>Document Number</label>
          </div>
          <div className='txt_field'>
            <input type="text" name="username" className='input_login' required />
            <span></span>
            <label className='w-100'>Email Adreess</label>
          </div>
          <div className='txt_field'>
            <input type="text" name="username" className='input_login' required />
            <span></span>
            <label className='w-100'>Telphone</label>
          </div>
          <div className='txt_field'>
            <input type="text" name="username" className='input_login' required />
            <span></span>
            <label className='w-100'>Password</label>
          </div>

          <div className='container text-center'>
            <input type="submit" name="" id="" value="Save" className='btn btn-primary btn_save' />
          </div>
        </form>
      </div>
    </div>
  )
}

export default DistribuidorsRegistration