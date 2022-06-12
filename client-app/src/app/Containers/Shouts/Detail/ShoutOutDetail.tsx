import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react';
import ShoutOutCard from '../Card/ShoutOutCard';
import { useShoutStore } from '../../../stores/stores';
import { RouteComponentProps } from 'react-router-dom';
import { Shout } from '../../../models/Shout';
import LoaderWithoutDimmer from '../../../Components/Loader/LoaderWithoutDimmer';
import NotFound from '../../../../NotFound';

interface IShoutOutDetail {
  id: string;
}

const ShoutOutDetail = ({ match }: RouteComponentProps<IShoutOutDetail>) => {
  const shoutStore = useShoutStore();
  const [shout, setShout] = useState<Shout>();
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [isErrored, setIsErrored] = useState<boolean>(false);

  useEffect(() => {
    const shout = shoutStore.shouts.find(
      (x) => x.id === Number(match.params.id)
    );

    if (!shout) {
      setIsErrored(true);
    }
    setShout(shout);
    setIsLoading(false);
  }, [match.params.id, shoutStore.shouts]);

  if (isLoading) {
    return <LoaderWithoutDimmer active content='Loading Shout Out...' />;
  }

  if (isErrored) {
    return <NotFound />;
  }

  return <ShoutOutCard shout={shout!} isDetailCard />;
};

export default observer(ShoutOutDetail);
