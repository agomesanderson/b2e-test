export default function PageLayout({ children }) {
    return (
      <div style={styles.wrapper}>
        <div style={styles.content}>
          {children}
        </div>
      </div>
    );
  }
  
  const styles = {
    wrapper: {
      minHeight: '100vh',
      width: '100vw',
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      backgroundColor: '#f3f4f6',
      padding: '16px',
      boxSizing: 'border-box',
    },
    content: {
      width: '100%',
      maxWidth: '800px',
      backgroundColor: '#fff',
      padding: '32px',
      borderRadius: '8px',
      boxShadow: '0 4px 12px rgba(0,0,0,0.1)',
      boxSizing: 'border-box',
    },
  };
  