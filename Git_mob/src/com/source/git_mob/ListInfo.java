package com.example.git_mob;

import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import com.jcraft.jsch.Channel;
import com.jcraft.jsch.ChannelExec;
import com.jcraft.jsch.JSch;
import com.jcraft.jsch.JSchException;
import com.jcraft.jsch.Session;

import android.app.Fragment;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;


public class ListInfo extends Fragment  {
	
	private List<NavDrawerItem> mylist = new ArrayList<NavDrawerItem>();

	public ListInfo() {
		SSHConnection remoteobj = new SSHConnection();
		remoteobj.execute();
		
		
	}
	void populateListView(String value){
		mylist.add(new NavDrawerItem(value));
		
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			 Bundle savedInstanceState) {	  
		
		View rootView = inflater.inflate(R.layout.listinfo, container, false);
		
	          
		return rootView;
	}
	
	 @Override
	public void onActivityCreated(Bundle savedInstanceState) {
		super.onActivityCreated(savedInstanceState);
		
	}

	
	 
	void displayprogress(String value){
		Toast.makeText(getActivity(), value, Toast.LENGTH_LONG).show();
		
	}



	class SSHConnection extends AsyncTask<Void, String, Void>{

	// Run on background thread
		@Override
		protected Void doInBackground(Void... params) {
		
			String command1="git reflog";
			JSch jsch = new JSch();
			try{
	             
	            java.util.Properties config = new java.util.Properties(); 
	            config.put("StrictHostKeyChecking", "no");
	            Session session=jsch.getSession("cs424306", "classes.csc.lsu.edu", 22);
	            session.setPassword("sdcnisui");
	            session.setConfig(config);
	            session.connect();
	            System.out.println("Connected");
	             
	            Channel channel=session.openChannel("exec");
	            ((ChannelExec)channel).setCommand("cd /classes/cs4243/svn/silverteam/silverteam.git  && git reflog");
	          //  ((ChannelExec)channel).setCommand(command1);
	            channel.setInputStream(null);
	            ((ChannelExec)channel).setErrStream(System.err);
	             
	            InputStream in=channel.getInputStream();
	            channel.connect();
	            byte[] tmp=new byte[1024];
	            while(true){
	              while(in.available()>0){
	                int i=in.read(tmp, 0, 1024);
	                if(i<0)break;
	                System.out.print(new String(tmp, 0, i));
	                publishProgress(new String(tmp, 0, i));
	              }
	              if(channel.isClosed()){
	                System.out.println("exit-status: "+channel.getExitStatus());
	                break;
	              }
	              try{Thread.sleep(1);}catch(Exception ee){}
	            }
	            channel.disconnect();
	            session.disconnect();
	            System.out.println("DONE");
	        }catch(Exception e){
	            e.printStackTrace();
	        }
	 
	    
		
		
			return null;
		}
		// Executed on Main UI thread
		@Override
		protected void onProgressUpdate(String... values) {
			// TODO Auto-generated method stub
			super.onProgressUpdate(values);
			for(String str:values){
				populateListView(str);
			}
			
		
		}

	
	

	