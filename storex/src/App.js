import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Login from './pages/Login/Login.jsx';
import UserRegistration from './pages/User/UserRegistration';
import ClientRegistration from './pages/Clients/ClientRegistration';
import DistribuidorsRegistration from './pages/Distribuidors/DistribuidorsRegsitration';
import UserDashboard from './pages/User/UserDashboard';
import Dashboard from './pages/Dashboard/Dashboard';
import ClientDashboard from './pages/Clients/ClientDashboard';
import DistribuidorsDashboard from './pages/Distribuidors/DistribuidorsDashboard';

function App() {
  return (
    //My routes
    <BrowserRouter>
      <Routes>
        {/* Login Page */}
        <Route index path='/'
          element={<Login />} />

        {/* Dashboard Page */}
        <Route path='dashboard' element={<Dashboard />} />

        {/* User Session */}
        <Route path='user' element={<UserDashboard />} />
        <Route path='user/registrationUser' element={<UserRegistration />} />

        {/* Client Session */}
        <Route path='client' element={<ClientDashboard />} />
        <Route path='client/registrationClient' element={<ClientRegistration />} />

        {/* Distribuidors Session */}
        <Route path='distribuidors' element={<DistribuidorsDashboard />} />
        <Route path='distribuidors/registrationDistribuidors' element={<DistribuidorsRegistration />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
