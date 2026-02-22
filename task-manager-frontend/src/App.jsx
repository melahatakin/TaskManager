import { useEffect, useState } from "react";
import axios from "axios";
import TaskForm from "./components/TaskForm";
import TaskList from "./components/TaskList";

const API_URL = "http://localhost:./api/tasks";

function App() {
  const [tasks, setTasks] = useState([]);

  const fetchTasks = () => {
    axios
      .get(API_URL)
      .then((res) => setTasks(res.data))
      .catch((err) => console.error(err));
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  const addTask = (task) => {
    axios
      .post(API_URL, task)
      .then(() => fetchTasks())
      .catch((err) => console.error(err));
  };

  const updateStatus = (id, status) => {
    axios
      .put(`${API_URL}/${id}/status?status=${status}`)
      .then(() => fetchTasks())
      .catch((err) => console.error(err));
  };

  return (
    <div style={{ padding: 20 }}>
      <h1>Task Manager</h1>

      <TaskForm onAdd={addTask} />

      <hr />

      <TaskList
        tasks={tasks}
        onStatusChange={updateStatus}
      />
    </div>
  );
}

export default App;
