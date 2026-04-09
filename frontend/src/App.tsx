import { useEffect, useState } from "react";

function App() {
  const [cases, setCases] = useState<any[]>([]);

  useEffect(() => {
    fetch("http://localhost:5000/api/case")
      .then(res => res.json())
      .then(setCases);
  }, []);

  return (
    <div>
      <h1>Cases</h1>
      {cases.map(c => (
        <div key={c.id}>
          {c.title} - {c.status}
        </div>
      ))}
    </div>
  );
}

export default App;
