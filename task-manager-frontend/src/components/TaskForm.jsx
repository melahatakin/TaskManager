import { useState } from "react";

function TaskForm({ onAdd }) {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  const submit = () => {
    if (!title.trim()) return;

    onAdd({
      title,
      description,
    });

    setTitle("");
    setDescription("");
  };

  return (
    <div>
      <h3>Yeni Görev</h3>

      <input
        placeholder="Title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />
      <br />

      <textarea
        placeholder="Description"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <br />

      <button onClick={submit}>Add Task</button>
    </div>
  );
}

export default TaskForm;
